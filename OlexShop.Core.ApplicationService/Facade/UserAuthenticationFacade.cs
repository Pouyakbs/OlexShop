using AutoMapper;
using OlexShop.Core.Contracts.Facade;
using OlexShop.Core.Contracts.Repository;
using OlexShop.Core.Domain.DTOs;
using OlexShop.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OlexShop.Core.ApplicationService.Facade
{
    public class UserAuthenticationFacade : IUserAuthenticationFacade
    {
        IUserAuthenticationRepository userAuthenticationRepository;
        private readonly IMapper mapper;
        public UserAuthenticationFacade(IUserAuthenticationRepository userAuthenticationRepository , IMapper mapper)
        {
            this.userAuthenticationRepository = userAuthenticationRepository;
            this.mapper = mapper;
        }
        public IEnumerable<UserAuthenticationDTO> GetAuthentications()
        {
            IEnumerable<UserAuthentication> users = userAuthenticationRepository.GetAuthentications();
            IEnumerable<UserAuthenticationDTO> usersDTOs = mapper.Map<IEnumerable<UserAuthentication>, IEnumerable<UserAuthenticationDTO>>(users);
            return usersDTOs;
        }
        public void AddUser(UserAuthenticationDTO userAuthentication)
        {
            UserAuthentication userDTO = mapper.Map<UserAuthenticationDTO, UserAuthentication>(userAuthentication);
            userAuthenticationRepository.AddUser(userDTO);
        }
        public void DeleteUser(int id)
        {
            userAuthenticationRepository.DeleteUser(id);
        }
        public UserAuthenticationDTO UserProfile(int id)
        {
            UserAuthentication user = userAuthenticationRepository.UserProfile(id);
            UserAuthenticationDTO userDTO = mapper.Map<UserAuthentication, UserAuthenticationDTO>(user);
            return userDTO;
        }
    }
}
