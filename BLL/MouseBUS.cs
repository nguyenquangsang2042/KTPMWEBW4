using KTPMWEBW4.DAO;
using KTPMWEBW4.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KTPMWEBW4.BLL
{
    public class MouseBUS
    {
        public List<Mouse> getAll()
        {
            List<Mouse> mouse = new MouseDAO().SelectAll();
            return mouse;

        }
    }
}