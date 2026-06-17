using System;
using System.Collections.Generic;
using System.Text;

namespace NAV_Prototyp_Vorlage.MessageEventBus
{
    
    public abstract class BaseEventMessage
    {   
        public string Text { get; set; }
        protected BaseEventMessage(string text )
        {
            this.Text= text;
        }
    }
    


}
