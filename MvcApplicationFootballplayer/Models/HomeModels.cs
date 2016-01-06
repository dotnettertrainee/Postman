using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using MvcApplicationFootballplayer.Data;

namespace MvcApplicationFootballplayer.Models
{

    public class PlayerView
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        [StringLength(250)]
        public string Name { get; set; }
        [Required]
        [StringLength(250)]
        public string Firstname { get; set; }
        [Required]
        [StringLength(100)]
        public string Printname { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{dd-MM-yyyy:0}", ApplyFormatInEditMode = true)]
        public DateTime Birthdate { get; set; }
        
        [Required]
        [StringLength(250)]
        public string Primary_Nationality { get; set; }

        [Required]
        public int Market_Value { get; set; }

        [Required]
        public bool Injured { get; set; }
        //public int MyProperty
        //{
        //    get { return myVar; }
        //    set { myVar = value; }
        //}
        //public int MyProperty { get; private set; }
        //public int MyProperty { get; set; }

        //public string MyProperty2 { get; set; }
        /*
        [Required]
        [StringLength(250)]
        public string Name { get; set; }
         */
    }

    public class TeamPlayerListView
    {
        public Team team { get; set; }
        public List<Player> playerList { get; set; }

        public List<Team> teamList { get; set; }
    }

    public class TeamListView
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        
        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Prefix { get; set; }

        [Required]
        [StringLength(250)]
        public string Nationality { get; set; }
    }

}