﻿using InvoiceMgmt.API.ApiModels;
using InvoiceMgmt.API.ActionFilters;
using InvoiceMgmt.API.ServiceModels;
using InvoiceMgmt.ApplicationCore.Entities;
using InvoiceMgmt.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using InvoiceMgmt.ApplicationCore.Specifications;

namespace InvoiceMgmt.API.Controllers;

[ApiController]
[Route("[controller]")]
public class InvoiceController : ControllerBase
{
    private readonly IInvoiceService _invoiceService;
    private readonly ILogger<InvoiceController> _logger;

    public InvoiceController(IInvoiceService invoiceService, ILogger<InvoiceController> logger)
    {
        _invoiceService = invoiceService;
        _logger = logger;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<Invoice>>> GetInvoices([FromQuery] InvoiceQueryParameters queryParameters, CancellationToken cancellationToken)
    {
        var spec = new InvoiceSpecification(queryParameters);
        var invoices = await _invoiceService.FindAsync(spec, cancellationToken);

        switch (queryParameters.SortBy)
        {
            case nameof(Invoice.CreatedAt):
                invoices = queryParameters.SortOrder == "Desc" ? invoices.OrderByDescending(s => s.CreatedAt) : invoices.OrderBy(s => s.CreatedAt);
                break;
            case nameof(Invoice.ChangedAt):
                invoices = queryParameters.SortOrder == "Desc" ? invoices.OrderByDescending(s => s.ChangedAt) : invoices.OrderBy(s => s.ChangedAt);
                break;
            default:
                invoices = queryParameters.SortOrder == "Desc" ? invoices.OrderByDescending(s => s.Number) : invoices.OrderBy(s => s.Number);
                break;
        }

        return Ok(invoices);
    }


    [HttpGet("{id:int}")]
    public async Task<ActionResult<Invoice>> GetInvoiceById([FromRoute] int id, CancellationToken cancellationToken)
    {
        return await _invoiceService.FindByIdAsync(id, cancellationToken);
    }


    [HttpPost]
    public async Task<IActionResult> CreateInvoice([FromBody] InvoiceCreateRequest input, CancellationToken cancellationToken)
    {
        //todo add automapper
        var createRequest = new CreateInvoiceInput
        {
            Amount = input.Amount,
            Number = input.Number,
            PaymentMethod = input.PaymentMethod
        };
        var newInvoice = await _invoiceService.CreateAsync(createRequest, cancellationToken);
        return CreatedAtAction(nameof(GetInvoiceById), new { id = newInvoice.Id }, newInvoice);
    }


    [HttpPut("{id:int}"), ValidateId]
    public async Task<IActionResult> ChangeInvoice([FromRoute] int id, [FromBody] InvoiceChangeRequest input, CancellationToken cancellationToken)
    {
        //todo add automapper
        var savedInvoice = await _invoiceService.FindByIdAsync(id, cancellationToken);

        if (savedInvoice == null)
            return NotFound(input);

        savedInvoice.Amount = input.Amount;
        savedInvoice.PaymentMethod = input.PaymentMethod;
        savedInvoice.State = input.State;

        await _invoiceService.ChangeAsync(savedInvoice);

        return Ok(savedInvoice);
    }
}

