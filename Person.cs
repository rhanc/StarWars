using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_5
{
    internal class Person
    {
        private int id_;
        private double mass_;
        private string name_;
        private string gender_;
        private int height_;
        private string human_;
        private string eye_color_;
        private string homeworld_;
        private string birth_year_;
        private string hair_color_;
        private string skin_color_;

        public Person(int id_, double mass_, string name_, string gender_, int height_, string human_, string eye_color_, string homeworld_, string birth_year_, string hair_color_, string skin_color_)
        {
            this.id_ = id_;
            this.mass_ = mass_;
            this.name_ = name_;
            this.gender_ = gender_;
            this.height_ = height_;
            this.human_ = human_;
            this.eye_color_ = eye_color_;
            this.homeworld_ = homeworld_;
            this.birth_year_ = birth_year_;
            this.hair_color_ = hair_color_;
            this.skin_color_ = skin_color_;
        }

        public int Id { get => id_; set => id_ = value; }
        public double Mass { get => mass_; set => mass_ = value; }
        public string Name { get => name_; set => name_ = value; }
        public string Gender { get => gender_; set => gender_ = value; }
        public int Height { get => height_; set => height_ = value; }
        public string Human { get => human_; set => human_ = value; }
        public string Eye_color { get => eye_color_; set => eye_color_ = value; }
        public string Homeworld { get => homeworld_; set => homeworld_ = value; }
        public string Birth_year { get => birth_year_; set => birth_year_ = value; }
        public string Hair_color { get => hair_color_; set => hair_color_ = value; }
        public string Skin_color { get => skin_color_; set => skin_color_ = value; }

        public override string ToString()
        {
            string str = "ID: "+Id+"\nMass: "+Mass+"\nName: "+Name+"\nGender: "+Gender+"\nHeight: "+Height;
            str += "\nHuman: " + Human + "\nEye Color: " + Eye_color + "\nHomeword: " + Homeworld;
            str += "\nBirth Year: " + Birth_year + "\nHair Color: " + Hair_color + "\nSkin Color: " + Skin_color;
            return str+"\n";
        }

        public bool IsEqual(string value, string field)
        {
            value = value.ToLower();
            bool result = false;
            if (Id.ToString() == value && field == "id")
            {
                result = true;
            }
            else if (Mass.ToString() == value && field == "mass")
            {
                result = true;
            }
            else if (Name.ToLower().Contains(value) && field == "name")
            {
                result = true;
            }
            else if (Gender.ToLower().Replace('"',' ').Trim() == (value) && field == "gender")
            {
                result = true;
            }
            else if (Height.ToString() == value && field == "height")
            {
                result = true;
            }
            else if (Human.ToLower().Contains(value) && field == "human")
            {
                result = true;
            }
            else if (Eye_color.ToLower().Contains(value) && field == "eye_color")
            {
                result = true;
            }
            else if (Homeworld.ToLower().Contains(value) && field == "homeworld")
            {
                result = true;
            }
            else if (Birth_year.ToLower().Contains(value) && field == "birth_year")
            {
                result = true;
            }
            else if (Hair_color.ToLower().Contains(value) && field == "hair_color")
            {
                result = true;
            }

            else if (Skin_color.ToLower().Contains(value) && field == "skin_color")
            {
                result = true;
            }
            return result;
        }
    }
}
