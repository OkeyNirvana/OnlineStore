using HobbyGarage.Models;

namespace HobbyGarage.Repository;

public interface IComparisonRepository
{
 public  Comparison? TryGetByUserId(string id);
 public void Add(Product product, string userid);
 public void Clear(string userid);
 public void Delete(int productid, string userid);
}

public class ComparisonRepository : IComparisonRepository
{
 private List<Comparison> _comparisons = [];

 public Comparison? TryGetByUserId(string id)
 {
   return _comparisons.FirstOrDefault((x => x.UserId == id));
 }

 public void Add(Product product, string userid)
 {
   var existingProduct = TryGetByUserId(userid);
   if (existingProduct == null)
   {
     existingProduct = new Comparison()
     {
         Items = [product],
         UserId = userid,
         Id = Guid.NewGuid()
     };
     _comparisons.Add(existingProduct);
   }
   else
   {
     var existingComparisonItem = existingProduct.Items.FirstOrDefault(x => x.Id == product.Id);
     existingProduct.Items.Add(product);
   }

 }

 public void Clear(string userid)
 {
   var existingComparison = TryGetByUserId(userid);
   if (existingComparison!= null) _comparisons.Remove(existingComparison);
 }

 public void Delete(int productid, string userid)
 {
   var existingComparison = TryGetByUserId(userid);
   var existingComparisonItems = existingComparison.Items.FirstOrDefault(x => x.Id == productid);
   if (existingComparisonItems != null) existingComparison.Items.Remove(existingComparisonItems);
 }
}