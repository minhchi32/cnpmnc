namespace cnpmnc.backend.Models;

public class Certificate
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime IssueDate { get; set; }
    public DateTime ExpiryDate { get; set; }
    public int CourseId { get; set; }
    public Course Course { get; set; }
}