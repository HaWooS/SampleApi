using SampleApi.Models;

namespace SampleApi.Utils.Randomizer
{
    public static class RandomPictureGenerator
    {
        #region GetRandomSubredditChild

        //Get random picture of the collection
        public static RandomImageModel? GetRandomSubredditChild(List<Data> children)
        {
            if (children != null && children.Count() > 0)
            {
                Random random = new Random();
                int index = random.Next(0, children.Count);
                return new RandomImageModel() { DateOfTheDraw = DateTime.Now.ToString(), ImageUrl = children[index].thumbnail };
            }
            else return null;
        }

        #endregion
    }
}
