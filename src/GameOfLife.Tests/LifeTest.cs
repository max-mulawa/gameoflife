using System;
using NUnit.Framework;

namespace GameOfLife.Tests
{
    [TestFixture]
    public class LifeTest
    {
         [Test]
         public void GetRegions_2x2_Returns4regions()
         {
             Life life = new Life(10);
             Region[] regions = life.GetRegions(4);
             Array.ForEach(regions, r => Console.WriteLine(r.ToString()));
             Assert.AreEqual(4, regions.Length);
         }

         [Test]
         public void GetRegions_3x3_Returns9regions()
         {
             Life life = new Life(10);
             Region[] regions = life.GetRegions(9);
             Array.ForEach(regions, r => Console.WriteLine(r.ToString()));
             Assert.AreEqual(9, regions.Length);
         }

         [Test]
         public void GetRegions_3x4_Returns9regions()
         {
             Life life = new Life(12);
             Region[] regions = life.GetRegions(9);
             Array.ForEach(regions, r => Console.WriteLine(r.ToString()));
             Assert.AreEqual(9, regions.Length);
         }    
    }
}