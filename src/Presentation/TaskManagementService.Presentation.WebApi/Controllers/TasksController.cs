using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TaskManagementService.Infrastructure.Dtos;
using TaskManagementService.Infrastructure.Repositories;

namespace TaskManagementService.Presentation.WebApi.Controllers;

[Route("[controller]")]
[ApiController]
public class TasksController : ControllerBase
{
    private readonly TaskRepository _taskRepository;

    public TasksController(TaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(int id)
    {
        var task = await _taskRepository.Get(id);

        var jsonSettings = new JsonSerializerSettings()
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };

        return Ok(JsonConvert.SerializeObject(task, Formatting.Indented, jsonSettings));
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var tasks = await _taskRepository.GetAll();

        var jsonSettings = new JsonSerializerSettings()
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };

        return Ok(JsonConvert.SerializeObject(tasks, Formatting.Indented, jsonSettings));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Create(CreateTaskDto dto)
    {
        var task = new Infrastructure.Entities.Task
        {
            Title = dto.Title,
            Description = dto.Description,
            EffortEstimation = dto.EffortEstimation,
            CreationDate = DateTime.Now.ToString("d"),
            Status = "new",
        };

        await _taskRepository.Add(task);

        return CreatedAtAction(nameof(Get), new { id = task.Id }, task);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Edit(int id, EditTaskDto dto)
    {
        var currentTask = await _taskRepository.Get(id);
        if (currentTask == null) return BadRequest();

        currentTask.Title = dto.Title;
        currentTask.Description = dto.Description;
        currentTask.EffortEstimation = dto.EffortEstimation;
        currentTask.Status = dto.Status;

        await _taskRepository.Edit(currentTask);
        return Ok(currentTask);

    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete(int id)
    {
        await _taskRepository.Delete(id);
        return NoContent();
    }

    [HttpPut("AssingSubTask/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> AssingSubTask(int id, AssingSubTaskDto dto)
    {
        var task = await _taskRepository.Get(id);
        if (task == null) return BadRequest();

        task.ParentTaskId = dto.ParentId;
        await _taskRepository.Edit(task);

        var parentTask = await _taskRepository.Get(task.ParentTaskId);

        var jsonSettings = new JsonSerializerSettings()
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };

        return Ok(JsonConvert.SerializeObject(parentTask, Formatting.Indented, jsonSettings));
    }
}
