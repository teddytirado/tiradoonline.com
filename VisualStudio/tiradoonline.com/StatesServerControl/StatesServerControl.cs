using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StatesServerControl
{
    [DefaultProperty("Text")]
    [ToolboxData("<tiradoonline:StatesControl runat=server></tiradoonline:StatesControl>")]
    public class StatesServerControl : WebControl
    {
        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        private string _className;
        public string className
        {
            get { return _className; }
            set { _className = value; }
        }

        private int _stateid;
        public int StateID
        {
            get { return _stateid; }
            set { _stateid = value; }
        }

        private string _statename;
        public string StateName
        {
            get { return _statename; }
            set { _statename = value; }
        }

        protected override void RenderContents(HtmlTextWriter output)
        {
            StringBuilder sbStates = new StringBuilder();

            Dictionary<int, string> states = new Dictionary<int, string>();
            states.Add(1001, "Alabama");
            states.Add(1002, "Alaska");
            states.Add(1003, "Arizona");
            states.Add(1004, "Arkansas");
            states.Add(1005, "California");
            states.Add(1006, "Colorado");
            states.Add(1007, "Connecticut");
            states.Add(1008, "Delaware");
            states.Add(1009, "District of Columbia");
            states.Add(1010, "Florida");
            states.Add(1011, "Georgia");
            states.Add(1012, "Hawaii");
            states.Add(1013, "Idaho");
            states.Add(1014, "Illinois");
            states.Add(1015, "Indiana");
            states.Add(1016, "Iowa");
            states.Add(1017, "Kansas");
            states.Add(1018, "Kentucky");
            states.Add(1019, "Louisiana");
            states.Add(1020, "Maine");
            states.Add(1021, "Maryland");
            states.Add(1022, "Massachusetts");
            states.Add(1023, "Michigan");
            states.Add(1024, "Minnesota");
            states.Add(1025, "Mississippi");
            states.Add(1026, "Missouri");
            states.Add(1027, "Montana");
            states.Add(1028, "Nebraska");
            states.Add(1029, "Nevada");
            states.Add(1030, "New Hampshire");
            states.Add(1031, "New Jersey");
            states.Add(1032, "New Mexico");
            states.Add(1033, "New York");
            states.Add(1034, "North Carolina");
            states.Add(1035, "North Dakota");
            states.Add(1036, "Ohio");
            states.Add(1037, "Oklahoma");
            states.Add(1038, "Oregon");
            states.Add(1039, "Pennsylvania");
            states.Add(1040, "Puerto Rico");
            states.Add(1052, "Rhode Island");
            states.Add(1041, "South Carolina");
            states.Add(1042, "South Dakota");
            states.Add(1043, "Tennessee");
            states.Add(1044, "Texas");
            states.Add(1045, "Utah");
            states.Add(1046, "Vermont");
            states.Add(1047, "Virginia");
            states.Add(1048, "Washington");
            states.Add(1049, "West Virgina");
            states.Add(1050, "Wisconsin");
            states.Add(1051, "Wyoming");

            int stateid = StateID;
            if (stateid == null)
                stateid = 0;

            string statename = StateName;
            if (statename == null)
                statename = string.Empty;

            sbStates.AppendLine("<select id='" + this.ID + "' name='" + this.ID + "' class='" + className + "'>");
            foreach (KeyValuePair<int, string> state in states)
            {
                if (Convert.ToInt32(state.Key) == Convert.ToInt32(stateid) || state.Value.ToString() == statename.ToString())
                    sbStates.AppendLine("<option value='" + state.Key + "'>" + state.Value + "</option>");
            }
            sbStates.AppendLine("</select>");

            output.Write(sbStates.ToString());
        }
    }
}
