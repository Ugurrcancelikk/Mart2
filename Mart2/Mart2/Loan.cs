namespace Mart2;

class Loan
{
    public int LoanId { get; set; }
    public Student Student { get; set; }
    public Book Book { get; set; }
    public DateTime LoanDate { get; set; }
}