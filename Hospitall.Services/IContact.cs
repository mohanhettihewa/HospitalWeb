using Hospitall.Utitilities;
using Hospitall.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospitall.Services
{
    public interface IContact
    {
        PagedResult<ContactViewModel> GetAll(int pageNumber, int pageSize);
        ContactViewModel GetContactById(int contactId);

        void UpdateContact(ContactViewModel contact);
        void DeleteContact(int contactId);

        void InsertContact(ContactViewModel contact);
    }
}
