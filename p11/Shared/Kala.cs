using System;
namespace P11.Shared
{
    public class kala
    {
        public string catagory{get;set;}
        public int price {get;set;}
        public string color {get;set;}
        public int ID {get;set;}
        public override int GetHashCode()
        {
            return this.ID;
        }
        public override bool Equals(object obj)
        {
            var other = obj as kala;
            if (obj is null) return false;
            return this.ID == other.ID;
        }

        public void SetValue(kala other)
        {
            this.price = other.price;
            this.catagory = other.catagory;
            this.color = other.color;
        }
    }
}
