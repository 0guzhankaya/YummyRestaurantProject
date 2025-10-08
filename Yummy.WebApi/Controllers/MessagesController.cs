using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Yummy.WebApi.Context;
using Yummy.WebApi.Dtos.MessageDtos;
using Yummy.WebApi.Entities;

namespace Yummy.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MessagesController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly ApiContext _context;

		public MessagesController(IMapper mapper, ApiContext context)
		{
			_mapper = mapper;
			_context = context;
		}

		[HttpGet]
		public IActionResult MessageList()
		{
			var values = _context.Messages.ToList();
			return Ok(_mapper.Map<List<ResultMessageDto>>(values));
		}

		[HttpGet("GetMessage")]
		public IActionResult GetMessage(int id)
		{
			var value = _context.Messages.Find(id);
			if (value == null)
			{
				return NotFound("Mesaj bulunamadı.");
			}
			return Ok(_mapper.Map<GetMessageDto>(value));
		}

		[HttpPost]
		public IActionResult CreateMessage(CreateMessageDto createMessageDto)
		{
			var value = _mapper.Map<Message>(createMessageDto); // Mapping işlemi sayesinde CreateMessageDto'dan Message entitysine dönüştürülüyor.
			_context.Messages.Add(value);
			_context.SaveChanges();
			return Ok("Mesaj ekleme işlemi başarılı.");
		}

		[HttpPut]
		public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
		{
			var value = _mapper.Map<Message>(updateMessageDto);
			_context.Messages.Update(value);
			_context.SaveChanges();
			return Ok("Mesaj güncelleme işlemi başarılı.");
		}

		[HttpDelete]
		public IActionResult DeleteMessage(int id)
		{
			var value = _context.Messages.Find(id);
			if (value == null)
			{
				return NotFound("Mesaj bulunamadı.");
			}
			_context.Messages.Remove(value);
			_context.SaveChanges();
			return Ok("Mesaj silme işlemi başarılı.");
		}
	}
}
