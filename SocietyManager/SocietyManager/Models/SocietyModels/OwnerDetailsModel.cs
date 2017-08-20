using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocietyManager.Models.SocietyModels
{
    public class OwnerDetailsModel
    {
        public int OwnerId { get; set; }
        public int FlatId { get; set; }
        public int SocietyId { get; set; }
        public PersonDetailsModel Person { get; set; }
    }

    public class OwnerList
    {
        public OwnerDetailsModel[] ownerList { get; set; }
        public string[] flatList { get; set; }

        public OwnerList(int numberOfflats,string[] flatList)
        {
            ownerList = new OwnerDetailsModel[numberOfflats];
            this.flatList = flatList;
        }

        public OwnerList()
        {

        }
    }
}