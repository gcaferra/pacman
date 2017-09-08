using System.Data.Common;
using FluentAssertions;
using Xunit;

namespace PacMan.Test
{
    public class PacManTest
    {

        [Fact]
        public void eating_dot_the_score_increment_by_10()
        {
            var sut = new PacMan(1,0);
            
            sut.Step("Dot");
            
            sut.Score.Should().Be(10);
        }
        
        [Theory]
        [InlineData("Cherry", 100)]
        [InlineData("Strawberry", 300)]
        [InlineData("Orange", 500)]
        [InlineData("Apple", 700)]
        [InlineData("Melon", 1000)]
        [InlineData("Galaxian", 2000)]
        [InlineData("Bell", 3000)]
        [InlineData("Key", 5000)]
        public void eating_fruit_the_score_should_adapt(string fruit, int points)
        {
            var sut = new PacMan(1,0);
            sut.Step(fruit);

            sut.Score.Should().Be(points);
        }

        [Fact]
        public void when_10k_score_new_life_is_added()
        {
            var sut = new PacMan(1,9000);
            sut.Step("Galaxian");

            sut.Lives.Should().Be(2);
            sut.Score.Should().Be(11000);

        }

        [Fact] public void when_10k_score_new_life_is_added_but_only_the_first_time()
        {
            var sut = new PacMan(1,9000);
            sut.Step("Galaxian");

            sut.Step("Cherry");
            sut.Lives.Should().Be(2);
            sut.Score.Should().Be(11100);
           

        }
        

    }
}