using System;
namespace ToolLibrary
{
    public class Tool
    {
        private string toolName;
        private int quantity;
        private int availability; 
        private int borrowedTimes;
        
        public string ToolName
        {
            get { return toolName; }
            set { toolName = value; }
        }
        public int Quantity 
        {
            get { return quantity; }
            set { quantity = value; }
        }
        public int Availability
        {
            get { return availability; }
            set { availability = value; }
        }
        public int BorrowedTimes
        {
            get { return borrowedTimes; }
            set { borrowedTimes = value; }
        }
        
        public Tool(string toolName, int quantity)
        {
            this.toolName = toolName;
            this.quantity = quantity;
        }
        public override string ToString()
        {
            return toolName.ToString() + " " + "Quantity: " + quantity ; 
        }
    }
}
