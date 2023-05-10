using System;

namespace SchoolManagement.ViewModel
{
    public class NoticeView
    {


        public int NoticeId { get; set; }
        public string NoticeDetails { get; set; }
        public DateTime? IssuedOn { get; set; }
        public int? IssuedBy { get; set; }
    }
}
