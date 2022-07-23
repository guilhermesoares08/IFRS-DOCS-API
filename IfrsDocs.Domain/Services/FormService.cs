
using IfrsDocs.Domain;
using IfrsDocs.Domain.Entities.Enums;
using System.Collections.Generic;

namespace IfrsDocs.Services
{
    public class FormService : BaseService<Form, IFormRepository>, IFormService
    {
        IUserRepository _userRepository;
        public FormService(IFormRepository formRepository, IUserRepository userRepository) : base(formRepository)
        {
            _userRepository = userRepository;
        }

        public List<Form> GetAllForms()
        {
            return _repository.GetAllForms();
        }

        public List<Form> GetFormsByUser(int userId)
        {
            return _repository.GetFormsByUser(userId);
        }

        public List<Form> GetPendingFormsByUser(int userId)
        {
            return _repository.GetPendingFormsByUser(userId);
        }

        public List<Form> GetPendingForms(int userId)
        {
            var user = _userRepository.GetUserById(userId);

            if(user == null || user.Role == null)
            {
                return null;
            }

            if(user.Role.Id == (int) RoleType.Admin)
            {
                return _repository.GetPendingForms();
            }

            return GetPendingFormsByUser(userId);
        }

        public Form GetFormById(int id)
        {
            return _repository.GetFormById(id);
        }

    }
}
