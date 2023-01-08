using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Student
{
    public class IStudent:IComparable<IStudent>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int marks { get; set; }
        public IStudent(int id,string name,int mark)
        {
            Id = id;
            Name = name;
            marks = mark;
        }
        public int CompareTo( [AllowNull]IStudent other)
        {
            if (this.Id > other.Id)
            {
                return 1;
            }
            else if (this.Id < other.Id)
            {
                return -1;
            }
            else 
            {
                return 0;
            }

        }
    }
}
