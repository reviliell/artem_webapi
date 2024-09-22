using Domain.Common;
using Domain.Models;

namespace WebApp.Responses;

public class GetUserListResponse
{
    public User[] Users { get; set; }
    public MetaInfo MetaInfo { get; set; }
}