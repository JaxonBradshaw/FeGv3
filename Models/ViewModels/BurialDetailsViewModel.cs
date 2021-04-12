using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeGv3.Models.ViewModels
{
    public class BurialDetailsViewModel
    {      
        public MainTbl BurialInfo { get; set; }                
        
        #nullable enable 
        public Bones? BonesInfo { get; set; }        
        public Biology? BiologyInfo{ get; set; }
        public Dictionary<Samples, Carbon>? SamplesAndCarbon { get; set; }        
    }
}
