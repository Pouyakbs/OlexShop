using AutoMapper;
using OlexShop.Core.Contracts.Facade;
using OlexShop.Core.Contracts.Repository;
using OlexShop.Core.Domain.DTOs;
using OlexShop.Core.Domain.Entities;
using System.Collections.Generic;

namespace OlexShop.Core.ApplicationService.Facade
{
    public class AdminAuthenticationFacade : IAdminAuthenticationFacade
    {
        IAdminAuthenticationRepository AdminAuthenticationRepository;
        private readonly IMapper mapper;
        public AdminAuthenticationFacade(IAdminAuthenticationRepository AdminAuthenticationRepository , IMapper mapper)
        {
            this.AdminAuthenticationRepository = AdminAuthenticationRepository;
            this.mapper = mapper;
        }
        public IEnumerable<AdminAuthenticationDTO> GetAuthentications()
        {
            IEnumerable<AdminAuthentication> admins = AdminAuthenticationRepository.GetAdmins();
            IEnumerable<AdminAuthenticationDTO> adminDTOs = mapper.Map<IEnumerable<AdminAuthentication>, IEnumerable<AdminAuthenticationDTO>>(admins);
            return adminDTOs;
        }
        public void AddAdmin(AdminAuthenticationDTO adminAuthentication)
        {
            AdminAuthentication userDTO = mapper.Map<AdminAuthenticationDTO, AdminAuthentication>(adminAuthentication);
            AdminAuthenticationRepository.AddAdmin(userDTO);
        }
        public void DeleteAdmin(int id)
        {
            AdminAuthenticationRepository.DeleteAdmin(id);
        }
    }
}
