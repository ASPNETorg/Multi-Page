using FullScaffold.Sample01.ApplicationServices.Dtos.PersonDtos;

namespace FullScaffold.Sample01.ApplicationServices.Frameworks.Contracts
{
    public interface IPersonService
    {
         Task Post(PostPersonServiceDto model);
    }
}
