namespace Sol.Domain.Dto;

public record StudentDto(
        int Id,
        string Surname,
        string Name,
        string ThirdName,
        int AcademicGroupId
    );