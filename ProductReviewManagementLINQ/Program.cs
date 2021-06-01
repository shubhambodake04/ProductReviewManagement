using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReviewManagementLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ProductReview> productReviews = new List<ProductReview>();
            Program program = new Program();
            //AddDefaultValues(productReviews);
            //GetTop3HighestRatedRecords(productReviews);
            //RatingGreaterThan3(productReviews);
            //CountforeachProductId(productReviews);
            //ProductIdWithReview(productReviews);
            //SkipTopFiveRecords(productReviews);
            program.AddInDataTable();
            Console.ReadKey();
        }
        static public void AddDefaultValues(List<ProductReview> productReviews)
        {
            productReviews.Add(new ProductReview() { productId = 1, userId = 1, rating = 5, isLike = "Yes", review = "Awesome" });
            productReviews.Add(new ProductReview() { productId = 1, userId = 2, rating = 3, isLike = "Yes", review = "Awesome" });
            productReviews.Add(new ProductReview() { productId = 1, userId = 3, rating = 4, isLike = "Yes", review = "Awesome" });
            productReviews.Add(new ProductReview() { productId = 1, userId = 4, rating = 3, isLike = "Yes", review = "Nice" });
            productReviews.Add(new ProductReview() { productId = 1, userId = 5, rating = 4, isLike = "Yes", review = "Good" });
            productReviews.Add(new ProductReview() { productId = 2, userId = 1, rating = 1, isLike = "No", review = "Unsatifactory" });
            productReviews.Add(new ProductReview() { productId = 2, userId = 2, rating = 3, isLike = "Yes", review = "Good" });
            productReviews.Add(new ProductReview() { productId = 2, userId = 3, rating = 4, isLike = "Yes", review = "Awesome" });
            productReviews.Add(new ProductReview() { productId = 2, userId = 4, rating = 3, isLike = "Yes", review = "Nice" });
            productReviews.Add(new ProductReview() { productId = 2, userId = 5, rating = 4, isLike = "Yes", review = "Good" });
            productReviews.Add(new ProductReview() { productId = 3, userId = 1, rating = 5, isLike = "Yes", review = "Awesome" });
            productReviews.Add(new ProductReview() { productId = 3, userId = 2, rating = 3, isLike = "Yes", review = "Awesome" });
            productReviews.Add(new ProductReview() { productId = 3, userId = 3, rating = 4, isLike = "Yes", review = "Awesome" });
            productReviews.Add(new ProductReview() { productId = 3, userId = 4, rating = 3, isLike = "Yes", review = "Nice" });
            productReviews.Add(new ProductReview() { productId = 3, userId = 5, rating = 4, isLike = "Yes", review = "Good" });
            productReviews.Add(new ProductReview() { productId = 4, userId = 1, rating = 1, isLike = "No", review = "Unsatifactory" });
            productReviews.Add(new ProductReview() { productId = 4, userId = 2, rating = 2, isLike = "No", review = "Bad" });
            productReviews.Add(new ProductReview() { productId = 4, userId = 3, rating = 2, isLike = "No", review = "Worst" });
            productReviews.Add(new ProductReview() { productId = 4, userId = 4, rating = 3, isLike = "No", review = "Not good" });
            productReviews.Add(new ProductReview() { productId = 4, userId = 5, rating = 2, isLike = "No", review = "Okay" });
            productReviews.Add(new ProductReview() { productId = 5, userId = 1, rating = 5, isLike = "Yes", review = "Awesome" });
            productReviews.Add(new ProductReview() { productId = 5, userId = 1, rating = 5, isLike = "Yes", review = "Awesome" });
            productReviews.Add(new ProductReview() { productId = 5, userId = 1, rating = 5, isLike = "Yes", review = "Awesome" });
            productReviews.Add(new ProductReview() { productId = 5, userId = 1, rating = 5, isLike = "Yes", review = "Awesome" });
            productReviews.Add(new ProductReview() { productId = 5, userId = 1, rating = 5, isLike = "Yes", review = "Awesome" });
            productReviews.Add(new ProductReview() { productId = 9, userId = 1, rating = 5, isLike = "Yes", review = "Unsatifactory" });
        }
        static public ArrayList GetTop3HighestRatedRecords(List<ProductReview> productReviews)
        {
            ArrayList outputList = new ArrayList();
            var highestRatedRows = (from rec in productReviews
                                    orderby rec.rating descending
                                    select rec).Take(3);
            foreach (var row in highestRatedRows)
            {
                Console.WriteLine(row.ToString());
                outputList.Add(row.ToString());
            }

            return outputList;

        }
        static public ArrayList RatingGreaterThan3(List<ProductReview> productReviews)
        {
            ArrayList outputList = new ArrayList();

            var records = (from rec in productReviews
                           where rec.rating > 3 && (rec.productId == 1 || rec.productId == 3 || rec.productId == 9)
                           select rec);
            foreach (var row in records)
            {
                Console.WriteLine(row.ToString());
                outputList.Add(row.ToString());
            }
            return outputList;
        }

        static public ArrayList CountforeachProductId(List<ProductReview> productReviews)
        {
            ArrayList outputList = new ArrayList();
            var records = (from rec in productReviews
                           group rec by rec.productId into g
                           select new
                           {
                               productId2 = g.Key,
                               ReviewCount = g.Count()
                           });
            foreach (var row in records)
            {
                Console.WriteLine(row.ToString());
                outputList.Add(row.ToString());
            }
            return outputList;
        }
        static public ArrayList ProductIdWithReview(List<ProductReview> productReviews)
        {
            ArrayList outputList = new ArrayList();
            var records = (from record in productReviews
                           select record);
            foreach (var row in records)
            {
                Console.WriteLine("ProductId: " + row.productId + " Review: " + row.review);
                outputList.Add(row.ToString());
            }
            return outputList;
        }
        static public ArrayList SkipTopFiveRecords(List<ProductReview> productReviews)
        {
            ArrayList outputList = new ArrayList();
            var records = (from record in productReviews
                           select record).Skip(5);
            foreach (var row in records)
            {
                Console.WriteLine(row.ToString());
                outputList.Add(row.ToString());
            }

            return outputList;

        }

        DataTable dt = new DataTable();

        public void AddInDataTable()
        {
            dt.Columns.Add("ProductId", typeof(int));
            dt.Columns.Add("UserId", typeof(int));
            dt.Columns.Add("Rating", typeof(int));
            dt.Columns.Add("Review", typeof(string));
            dt.Columns.Add("IsLike", typeof(string));
            dt.Rows.Add(1, 1, 5, "Awesome", "Yes");
            dt.Rows.Add(1, 2, 3, "Good", "Yes");
            dt.Rows.Add(2, 3, 4, "Good", "No");
            dt.Rows.Add(1, 4, 3, "Good", "No");
            dt.Rows.Add(2, 5, 4, "Nice", "Yes");
            dt.Rows.Add(2, 1, 1, "Not good", "No");
            dt.Rows.Add(2, 2, 3, "Awesome", "Yes");
            dt.Rows.Add(3, 3, 4, "Awesome", "Yes");
            dt.Rows.Add(3, 4, 3, "Awesome", "Yes");
            dt.Rows.Add(3, 5, 4, "Awesome", "Yes");
            dt.Rows.Add(3, 1, 5, "Awesome", "Yes");
            dt.Rows.Add(3, 2, 3, "Awesome", "Yes");
            dt.Rows.Add(4, 3, 4, "Good", "No");
            dt.Rows.Add(4, 4, 5, "Good", "No");
            dt.Rows.Add(4, 5, 3, "Good", "Yes");
            dt.Rows.Add(5, 1, 4, "Nice", "Yes");
            dt.Rows.Add(5, 2, 3, "Awesome", "Yes");
            dt.Rows.Add(5, 3, 4, "Not good", "No");
            dt.Rows.Add(5, 4, 1, "Nice", "Yes");
            dt.Rows.Add(5, 5, 3, "Unsatifactory", "No");
            dt.Rows.Add(7, 1, 4, "Awesome", "Yes");
            dt.Rows.Add(7, 1, 3, "Awesome", "Yes");
            dt.Rows.Add(9, 1, 4, "Worst", "No");
            dt.Rows.Add(9, 1, 5, "Good", "No");
            dt.Rows.Add(9, 1, 3, "Unsatifactory", "No");
            foreach (DataRow R in dt.Rows)
            {
                Console.WriteLine(R["ProductId"] + " " + R["UserId"] + " " + R["Rating"] + " " + R["Review"] + " " + R["IsLike"] + " ");
            }
        }
        
    }
}
