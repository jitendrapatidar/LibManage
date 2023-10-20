using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using veripark.DataAccess.Models;
using veripark.UnitofWork;
using veripark.ViewMode.Entities;
using AutoMapper;
 

namespace veripark.Infrastructure.Impl
{
    public class RoleService
        : IRoleService
    {
        private readonly ILmsImpl _lmsImpl;
        private readonly IMapper _mapper;
      

        public RoleService(ILmsImpl lmsImpl, IMapper mapper)
        {
            _lmsImpl = lmsImpl;
            _mapper = mapper;

        }

        public IEnumerable<RoleEntity> GetAll()
        {
            var roledetails = _lmsImpl.roleRepository.GetAll();

            if (roledetails == null) return new List<RoleEntity>();
            var roleentity = _mapper.Map<IEnumerable<Role>, IEnumerable<RoleEntity>>(roledetails);

            return roleentity;
        }
        public RoleEntity GetById(int id)
        {
            var role = _lmsImpl.roleRepository.Find(e => e.Id == id).FirstOrDefault();
            var roleentity = _mapper.Map<Role,RoleEntity>(role);
            
            return roleentity;
        }
        public Int32 Save(RoleEntity obj)
        {


            var role = _mapper.Map<RoleEntity, Role>(obj);
           
            _lmsImpl.roleRepository.Add(role);
            int result = _lmsImpl.Save();
            return result;
        }
        public Int32 Update(int id, RoleEntity obj)
        {
            var role = _lmsImpl.roleRepository.FirstOrDefault(e => e.Id == id);
            if (role != null)
            {
                 
                role.Name = obj.Name;
                role.IsActive = obj.IsActive;
                _lmsImpl.roleRepository.Update(role);
                _lmsImpl.Dispose();
                return 1;

            }
            return 0;
        }
        public Int32 Delete(int id)
        {
            var role = _lmsImpl.roleRepository.FirstOrDefault(e => e.Id == id);
            if (role != null)
            {
                _lmsImpl.roleRepository.Remove(role);
                _lmsImpl.Save();
                return 1;
            }
            return 0;
        }


    }
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<Role, RoleEntity>();
            //.ForMember(dst => dst.Authors, opt => opt.MapFrom(x => x.BookAuthors.Select(y => y.Author).ToList()))
            //.ForMember(dst => dst.Subjects, opt => opt.MapFrom(x => x.BookSubjects.Select(y => y.Subject).ToList()));
        }
    }
}
