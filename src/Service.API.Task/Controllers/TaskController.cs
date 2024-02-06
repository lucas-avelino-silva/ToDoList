using Application.Service;
using Application.ViewModel;
using FluentValidation;
using Infra.CrossCutting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Service.API.Task.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/tasks")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskApplicationService _TaskAppService;
        private IValidator<InputTaskViewModel> _validator;
        public TaskController(ITaskApplicationService taskAppService, IValidator<InputTaskViewModel> validator)
        {
            _TaskAppService = taskAppService;
            _validator = validator;
        }

        [HttpGet]
        public async Task<APIResponse<List<TaskViewModel>>> GetTasks()
        {
            var response = new APIResponse<List<TaskViewModel>>();

            if (ModelState.IsValid)
            {
                try
                {
                    var tasks = await _TaskAppService.GetAll();

                    response.SetContent(200, tasks);
                }
                catch (Exception ex)
                {
                    response.AddInformation(500, ex.Message);
                }
            }
            else
            {
                ModelState.Values.SelectMany(x => x.Errors).ToList().ForEach(x => response.AddInformation(400, x.ErrorMessage));
            }

            return response.Response();
        }

        [HttpPost]
        public async Task<APIResponse<InputTaskViewModel>> InsertTask([FromBody] InputTaskViewModel task)
        {
            var response = new APIResponse<InputTaskViewModel>();

            var valid = await _validator.ValidateAsync(task);

            if (valid.IsValid)
            {
                try
                {
                    await _TaskAppService.Add(task);

                    response.SetContent(201, task);
                }
                catch (Exception ex)
                {
                    response.AddInformation(500, ex.Message);
                }
            }
            else
            {
                valid.Errors.ForEach(x => response.AddInformation(400, x.ErrorMessage));
            }

            return response.Response();
        }

        [HttpPut("{id:guid}")]
        public async Task<APIResponse<bool>> UpdateTask([FromRoute] Guid id, [FromBody] InputTaskViewModel task)
        {
            var response = new APIResponse<bool>();

            var valid = await _validator.ValidateAsync(task);

            if (valid.IsValid)
            {
                try
                {
                    var retorno = await _TaskAppService.UpdateTask(id, task);

                    if (!retorno.IsValid())
                    {
                        retorno.Errors!.ForEach(x => response.AddInformation(400, x));

                        return response.Response();
                    }

                    response.SetContent(200, retorno.Content);
                }
                catch (Exception ex)
                {
                    response.AddInformation(500, ex.Message);
                }
            }
            else
            {
                valid.Errors.ForEach(x => response.AddInformation(400, x.ErrorMessage));
            }

            return response.Response();
        }

        [HttpDelete("{id:guid}")]
        public async Task<APIResponse<bool>> DeleteTask([FromRoute] Guid id)
        {
            var response = new APIResponse<bool>();

            if (ModelState.IsValid)
            {
                try
                {
                    var retorno = await _TaskAppService.Delete(id);

                    if (!retorno.IsValid())
                    {
                        retorno.Errors!.ForEach(x => response.AddInformation(400, x));

                        return response.Response();
                    }

                    response.SetContent(200, retorno.Content);
                }
                catch (Exception ex)
                {
                    response.AddInformation(500, ex.Message);
                }
            }
            else
            {
                ModelState.Values.SelectMany(x => x.Errors).ToList().ForEach(x => response.AddInformation(400, x.ErrorMessage));
            }

            return response.Response();
        }
    }
}