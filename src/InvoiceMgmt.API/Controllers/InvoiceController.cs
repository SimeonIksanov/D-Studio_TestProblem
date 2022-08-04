using InvoiceMgmt.API.ApiModels;
using InvoiceMgmt.API.Filters;
using InvoiceMgmt.API.ServiceModels;
using InvoiceMgmt.ApplicationCore.Entities;
using InvoiceMgmt.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

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
    public async Task<ActionResult<IEnumerable<Invoice>>> GetInvoices(CancellationToken cancellationToken)
    {
        var invoices = await _invoiceService.GetAllAsync(cancellationToken);
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

