using System.Collections.Generic;

namespace CodeAnalysisToolLogic.Models
{
    public class AnalysisResult
    {
        public List<string> ReportDetails { get; set; } = new List<string>();
        public int TotalLOC { get; set; }
        public int TotalELOC { get; set; }
        public int ClassCount { get; set; }
        public int InterfaceCount { get; set; }
        public bool HasInheritance { get; set; }
        public double AverageCoupling { get; set; }
        public double AverageCohesion { get; set; }
        public int MaxNestingDepth { get; set; }

        public List<ClassDetails> ClassDetails { get; set; }
    }

    public class ClassDetails
    {
        public string ClassName { get; set; }
        public string ParentClassName { get; set; }
        public int AttributeCount { get; set; }
        public int MethodCount { get; set; }
        public bool HasInnerClass { get; set; }
        public int LOC { get; set; }
        public int ELOC { get; set; }
        public double AverageELOCPerMethod { get; set; }
        public int MaxELOCForMethod { get; set; }
        public List<string> MethodsExceedingMALOC { get; set; }
        public int MaxNestingDepth { get; set; }
        public double Coupling { get; set; }
        public double Cohesion { get; set; }
    }
}