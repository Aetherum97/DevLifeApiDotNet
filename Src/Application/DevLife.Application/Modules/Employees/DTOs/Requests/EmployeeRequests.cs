using System;

namespace DevLife.Application.Modules.Employees.DTOs.Requests;

public class EmployeeCreateRequest()
{
    public required Guid CompanyId { get; set; }
    public required Guid EmployeeNameId { get; set; }
    public required ICollection<Guid> EmployeeSkills { get; set; }
    public required int Level { get; set; }
    public required int Salary { get; set; }
    public required int Experience { get; set; }
    public required int CFrontEnd { get; set; }
    public required int CBackEnd { get; set; }
    public required int CDevops { get; set; }
    public required int CDatabase { get; set; }
    public required bool IsAvalaible { get; set; }
}

public class EmployeeUpdateRequest()
{
    public required Guid Id { get; set; }
    public required Guid CompanyId { get; set; }
    public required Guid EmployeeNameId { get; set; }
    public required ICollection<Guid> EmployeeSkills { get; set; }
    public required int Level { get; set; }
    public required int Salary { get; set; }
    public required int Experience { get; set; }
    public required int CFrontEnd { get; set; }
    public required int CBackEnd { get; set; }
    public required int CDevops { get; set; }
    public required int CDatabase { get; set; }
    public required bool IsAvalaible { get; set; }
}

public class EmployeeDeleteRequest()
{
    public required Guid Id { get; set; }
    public required Guid CompanyId { get; set; }
}

