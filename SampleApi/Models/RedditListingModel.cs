namespace SampleApi.Models
{

        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

        public class AllAwarding
        {
            public string giver_coin_reward { get; set; }
            public string subreddit_id { get; set; }
            public string is_new { get; set; }
            public string days_of_drip_extension { get; set; }
            public string coin_price { get; set; }
            public string id { get; set; }
            public string penny_donate { get; set; }
            public string award_sub_type { get; set; }
            public string coin_reward { get; set; }
            public string icon_url { get; set; }
            public string days_of_premium { get; set; }
            public string tiers_by_required_awardings { get; set; }
            public List<ResizedIcon> resized_icons { get; set; }
            public string icon_width { get; set; }
            public string static_icon_width { get; set; }
            public string start_date { get; set; }
            public string is_enabled { get; set; }
            public string awardings_required_to_grant_benefits { get; set; }
            public string description { get; set; }
            public string end_date { get; set; }
            public string sticky_duration_seconds { get; set; }
            public string subreddit_coin_reward { get; set; }
            public string count { get; set; }
            public string static_icon_height { get; set; }
            public string name { get; set; }
            public List<ResizedStaticIcon> resized_static_icons { get; set; }
            public string icon_format { get; set; }
            public string icon_height { get; set; }
            public string penny_price { get; set; }
            public string award_type { get; set; }
            public string static_icon_url { get; set; }
        }

        public class AuthorFlairRichtext
        {
            public string a { get; set; }
            public string e { get; set; }
            public string u { get; set; }
            public string t { get; set; }
        }

        public class Child
        {
            public string kind { get; set; }
            public Data data { get; set; }
        }

        public class Data
        {
            public string after { get; set; }
            public string dist { get; set; }
            public string modhash { get; set; }
            public string geo_filter { get; set; }
            public List<Child> children { get; set; }
            public string before { get; set; }
            public string approved_at_utc { get; set; }
            public string subreddit { get; set; }
            public string selftext { get; set; }
            public string author_fullname { get; set; }
            public string saved { get; set; }
            public string mod_reason_title { get; set; }
            public string gilded { get; set; }
            public string clicked { get; set; }
            public string title { get; set; }
            public List<LinkFlairRichtext> link_flair_richtext { get; set; }
            public string subreddit_name_prefixed { get; set; }
            public string hidden { get; set; }
            public string pwls { get; set; }
            public string link_flair_css_class { get; set; }
            public string downs { get; set; }
            public string thumbnail_height { get; set; }
            public string top_awarded_type { get; set; }
            public string hide_score { get; set; }
            public string name { get; set; }
            public string quarantine { get; set; }
            public string link_flair_text_color { get; set; }
            public string upvote_ratio { get; set; }
            public string author_flair_background_color { get; set; }
            public string subreddit_type { get; set; }
            public string ups { get; set; }
            public string total_awards_received { get; set; }
            public MediaEmbed media_embed { get; set; }
            public string thumbnail_width { get; set; }
            public string author_flair_template_id { get; set; }
            public string is_original_content { get; set; }
            public List<object> user_reports { get; set; }
            public SecureMedia secure_media { get; set; }
            public string is_reddit_media_domain { get; set; }
            public string is_meta { get; set; }
            public string category { get; set; }
            public SecureMediaEmbed secure_media_embed { get; set; }
            public string link_flair_text { get; set; }
            public string can_mod_post { get; set; }
            public string score { get; set; }
            public string approved_by { get; set; }
            public string is_created_from_ads_ui { get; set; }
            public string author_premium { get; set; }
            public string thumbnail { get; set; }
            public string edited { get; set; }
            public string author_flair_css_class { get; set; }
            public List<AuthorFlairRichtext> author_flair_richtext { get; set; }
            public Gildings gildings { get; set; }
            public string content_categories { get; set; }
            public string is_self { get; set; }
            public string mod_note { get; set; }
            public string created { get; set; }
            public string link_flair_type { get; set; }
            public string wls { get; set; }
            public string removed_by_category { get; set; }
            public string banned_by { get; set; }
            public string author_flair_type { get; set; }
            public string domain { get; set; }
            public string allow_live_comments { get; set; }
            public string selftext_html { get; set; }
            public string likes { get; set; }
            public string suggested_sort { get; set; }
            public string banned_at_utc { get; set; }
            public string view_count { get; set; }
            public string archived { get; set; }
            public string no_follow { get; set; }
            public string is_crosspostable { get; set; }
            public string pinned { get; set; }
            public string over_18 { get; set; }
            public List<AllAwarding> all_awardings { get; set; }
            public List<object> awarders { get; set; }
            public string media_only { get; set; }
            public string link_flair_template_id { get; set; }
            public string can_gild { get; set; }
            public string spoiler { get; set; }
            public string locked { get; set; }
            public string author_flair_text { get; set; }
            public List<object> treatment_tags { get; set; }
            public string visited { get; set; }
            public string removed_by { get; set; }
            public string num_reports { get; set; }
            public string distinguished { get; set; }
            public string subreddit_id { get; set; }
            public string author_is_blocked { get; set; }
            public string mod_reason_by { get; set; }
            public string removal_reason { get; set; }
            public string link_flair_background_color { get; set; }
            public string id { get; set; }
            public string is_robot_indexable { get; set; }
            public string report_reasons { get; set; }
            public string author { get; set; }
            public string discussion_type { get; set; }
            public string num_comments { get; set; }
            public string send_replies { get; set; }
            public string whitelist_status { get; set; }
            public string contest_mode { get; set; }
            public List<object> mod_reports { get; set; }
            public string author_patreon_flair { get; set; }
            public string author_flair_text_color { get; set; }
            public string permalink { get; set; }
            public string parent_whitelist_status { get; set; }
            public string stickied { get; set; }
            public string url { get; set; }
            public string subreddit_subscribers { get; set; }
            public string created_utc { get; set; }
            public string num_crossposts { get; set; }
            public Media media { get; set; }
            public string is_video { get; set; }
            public string post_hint { get; set; }
            public Preview preview { get; set; }
            public string url_overridden_by_dest { get; set; }
            //public MediaMetadata media_metadata { get; set; }
            public string call_to_action { get; set; }
        }

        public class Gildings
        {
            public string gid_1 { get; set; }
        }

        public class Image
        {
            public Source source { get; set; }
            public List<Resolution> resolutions { get; set; }
            //public Variants variants { get; set; }
            public string id { get; set; }
        }

        public class LinkFlairRichtext
        {
            public string e { get; set; }
            public string t { get; set; }
        }

        public class Media
        {
            public string type { get; set; }
            public Oembed oembed { get; set; }
        }

        public class MediaEmbed
        {
            public string content { get; set; }
            public string width { get; set; }
            public string scrolling { get; set; }
            public string height { get; set; }
        }

        public class Oembed
        {
            public string provider_url { get; set; }
            public string version { get; set; }
            public string title { get; set; }
            public string type { get; set; }
            public string thumbnail_width { get; set; }
            public string height { get; set; }
            public string width { get; set; }
            public string html { get; set; }
            public string author_name { get; set; }
            public string provider_name { get; set; }
            public string thumbnail_url { get; set; }
            public string thumbnail_height { get; set; }
            public string author_url { get; set; }
        }

        public class P
        {
            public string y { get; set; }
            public string x { get; set; }
            public string u { get; set; }
        }

        public class Preview
        {
            public List<Image> images { get; set; }
            public string enabled { get; set; }
        }

        public class ResizedIcon
        {
            public string url { get; set; }
            public string width { get; set; }
            public string height { get; set; }
        }

        public class ResizedStaticIcon
        {
            public string url { get; set; }
            public string width { get; set; }
            public string height { get; set; }
        }

        public class Resolution
        {
            public string url { get; set; }
            public string width { get; set; }
            public string height { get; set; }
        }

        public class RedditListingModel
        {
            public string kind { get; set; }
            public Data data { get; set; }
        }

        public class S
        {
            public string y { get; set; }
            public string x { get; set; }
            public string u { get; set; }
        }

        public class SecureMedia
        {
            public string type { get; set; }
            public Oembed oembed { get; set; }
        }

        public class SecureMediaEmbed
        {
            public string content { get; set; }
            public string width { get; set; }
            public string scrolling { get; set; }
            public string media_domain_url { get; set; }
            public string height { get; set; }
        }

        public class Source
        {
            public string url { get; set; }
            public string width { get; set; }
            public string height { get; set; }
        }

        //public class Variants
        //{
        //}
}
