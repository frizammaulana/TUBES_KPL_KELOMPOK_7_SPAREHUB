using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UlasanDanRatingProduk
{
    public class ReviewService
    {
        private readonly Dictionary<string, List<Review>> reviewMap = new();

        public void AddReview(string productId, Review review)
        {
            if (!reviewMap.ContainsKey(productId))
                reviewMap[productId] = new List<Review>();

            reviewMap[productId].Add(review);
        }

        public void ShowReviews(string productId)
        {
            if (!reviewMap.ContainsKey(productId) || reviewMap[productId].Count == 0)
            {
                Console.WriteLine("Belum ada ulasan untuk produk ini.");
                return;
            }

            foreach (var review in reviewMap[productId])
            {
                review.Display();
            }
        }
    }
}
