using AutoMapper;
using FormulaOne.DataServices.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Into_CQRS_MediatR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {

        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;


        public BaseController(IUnitOfWork unitOfWork, IMapper mapper) 
        {
        
            _unitOfWork = unitOfWork;   
            _mapper = mapper;
        
        
        
        }









    }
}
