using Hospitall.Models;
using Hospitall.Repositories.Implementation;
using Hospitall.Utitilities;
using Hospitall.ViewModels;
using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Hospitall.Services
{
    public class ContactService : IContact
    {

        private IUnitOfWork _unitOfWork;
     

        public ContactService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void DeleteContact(int contactId)
        {
            var model=_unitOfWork.GenericRepository<Contact>().GetBYId(contactId);  
            _unitOfWork.GenericRepository<Contact>().Delete(model);
            _unitOfWork.Save();
        }

        public PagedResult<ContactViewModel> GetAll(int pageNumber, int pageSize)
        {
            var vm= new ContactViewModel();
            int totalCount;
            List<ContactViewModel> VMLIST= new List<ContactViewModel>();
            try
            {

                int ExcludeRecords = (pageSize * pageNumber) - pageSize;
                var modellist = _unitOfWork.GenericRepository<Contact>().GetAll().Skip(ExcludeRecords).Take(pageSize).ToList();
                totalCount= _unitOfWork.GenericRepository<Contact>().GetAll().ToList().Count;
                VMLIST = ConvertToViewModelList(modellist);
            }

            catch (Exception )
            {
                throw;

            }
            var result = new PagedResult<ContactViewModel>
            {
                Data = VMLIST,
                TotalItems=totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize



            };
            return result;
        }

        private List<ContactViewModel> ConvertToViewModelList(List<Contact> modellist)
        {
            return modellist.Select(x=>new ContactViewModel(x)).ToList();   
        }

        public ContactViewModel GetContactById(int contactId)
        {
            var model=_unitOfWork.GenericRepository<Contact>().GetBYId(contactId);
            var vm=new ContactViewModel(model);
            return vm;  
        }

        public void InsertContact(ContactViewModel contact)
        {
           var model=new ContactViewModel().ConvertViewModel(contact);
            _unitOfWork.GenericRepository<Contact>().Add(model);
            _unitOfWork.Save();
        }

        public void UpdateContact(ContactViewModel contact)
        {
            var model = new ContactViewModel().ConvertViewModel(contact);   
            var ModelById=_unitOfWork.GenericRepository<Contact>().GetBYId(model.Id);
            ModelById.Phone= contact.Phone;
            ModelById.Email= contact.Email;
            ModelById.HospitalId = contact.HospitalInfoId;
            _unitOfWork.GenericRepository<Contact>().Update(ModelById);
            _unitOfWork.Save();


        }
    }
}
