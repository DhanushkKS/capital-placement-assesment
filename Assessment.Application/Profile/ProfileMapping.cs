using Assessment.Application.Dtos;
using Assessment.Domain.Question;

namespace Assessment.Application.Profile;

public class ProfileMapping:AutoMapper.Profile
{
    public ProfileMapping()
    {
        CreateMap<CreateQuestionDto, Question>();
    }
}