using Domain.Models;

namespace Domain.Interfaces
{
    public interface ISocialMediaRepository
    {
        SocialMediaID AddSocialMedia(SocialMediaID socialMediaIDs);
        SocialMediaID GetSocialMedia(int ID);
        SocialMediaID UpdateSocialMedia(SocialMediaID socialMediaIDs);
    }
}
