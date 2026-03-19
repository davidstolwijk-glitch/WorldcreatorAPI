using System.ComponentModel.DataAnnotations;

namespace Worldcreator.Models
{
    public class Object2D
    {


        public string PrefabId { get; set; }
        
        public Guid Id { get; set; }

        public Guid EnvironmentId { get; set; }
        
        public double PositionX { get; set; }
        
        public double PositionY { get; set; }

        public double ScaleX { get; set; }

        public double ScaleY { get; set; }

        public double RotationZ { get; set; }

        public int SortingLayer { get; set; }
    }
}
