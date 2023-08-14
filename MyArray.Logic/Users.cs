using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyArray.Logic
{
    public class Users
    {
        private string? _email;
        private string? _lastname;
        private string? _name;
        private bool _isAdmin;
        private int _cedula;

        public Users()
        {
            _email = string.Empty;
            _name = string.Empty;
            _lastname = string.Empty;
            _cedula = 0;
            _isAdmin = false;
        }

        public Users(string email, string name, string lastname, int cedula, bool isAdmin)
        {
            throw new System.NotImplementedException();
        }

        public int IsAdmin
        {
            get => default;
            set
            {
            }
        }
    }
}