using Application.ViewModels;

namespace Application.Interfaces
{
    public interface ISocialMediaService
    {
        SocialMediaIDDto SaveSocialMedia(SocialMediaIDDto socialMediaIDs);
        SocialMediaIDDto GetSocialMedia(int ID);
    }
}
