namespace TeaShopApi.WebUI.Dtos.SocialMediaDtos
{
    public class UpdateSocialMediaDto
    {
        public int SocialMediaID { get; set; }
        public string? ImageURL { get; set; }
        public string? URL { get; set; }
        public bool SocialMediaStatus { get; set; }
    }
}
