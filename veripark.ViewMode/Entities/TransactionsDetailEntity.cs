﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;

namespace veripark.ViewMode.Entities;
 
public partial class TransactionsDetailEntity
{
    
    public int Id { get; set; }
    public int? BookId { get; set; }
    public int? BorrowerId { get; set; }
    public DateTime? IssueDate { get; set; }
    public DateTime? DueDate { get; set; }
    public bool? IsReturned { get; set; }
    public int? MaxDate { get; set; }
    public bool? IsIssue { get; set; }
    public DateTime? OnDate { get; set; }
    
}