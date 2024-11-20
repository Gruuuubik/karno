using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace Karno.UnitTests
{
	public class KMapTests
	{
		public static IEnumerable<object[]> PrintCoverages_TestData()
		{
			yield return new object[] { new KMap(4, [0, 1, 2, 4, 5, 9, 10, 11, 13, 15], []) };
			yield return new object[] { new KMap(4, [0, 2, 4, 5, 10, 11, 13, 15], []) };
			yield return new object[] { new KMap(8, [1, 5, 7, 9, 13, 17, 21, 23, 25, 29, 31, 33, 37, 39, 41, 45, 49, 53, 55, 57, 61, 65, 69, 71, 73, 77, 81, 85, 87, 89, 93, 95, 97, 101, 103, 105, 109, 113, 117, 119, 121, 125, 127, 129, 133, 135, 137, 141, 145, 149, 151, 153, 157, 159, 161, 165, 167, 169, 173, 177, 181, 183, 185, 189, 193, 197, 199, 201, 205, 209, 213, 215, 217, 221, 223, 225, 229, 231, 233, 237, 241, 245, 247, 249, 253], []) };
			yield return new object[] { new KMap(3, [0, 1, 2, 3, 7], []) };
			yield return new object[] { new KMap(4, [1, 11, 12, 13, 14, 15], [3, 4, 5, 9]) };
			yield return new object[] { new KMap(5, [2, 5, 7, 8, 10, 13, 15, 17, 19, 21, 23, 24, 29, 31], []) };
		}

		[Theory]
		[MemberData(nameof(PrintCoverages_TestData))]
		public void Given_KMap_When_PrintCoverages_Then_ReturnCorrectValue(KMap map)
		{
			map.PrintCoverages(true);
			map.PrintTestResults();
		}

		public static IEnumerable<object[]> Minimize_TestData()
		{
			yield return new object[]
			{
				new KMap(2, [0, 1], []),
				new HashSet<Coverage>
				{
					new Coverage(new List<Group>
					{
						new Group(new List<string>
						{
							"00",
							"01"
						})
					})
				}
			};

			yield return new object[]
			{
				new KMap(3, [0, 1, 2, 3, 7], []),
				new HashSet<Coverage>
				{
					new Coverage(new List<Group>
					{
						new Group(new List<string>
						{
							"011",
							"111"
						}),
						new Group(new List<string>
						{
							"000",
							"001",
							"010",
							"011"
						})
					})
				}
			};

			yield return new object[]
			{
				new KMap(4, [0, 1, 2, 4, 5, 9, 10, 11, 13, 15], []),
				new HashSet<Coverage>
				{
					new Coverage(new List<Group>
					{
						new Group(new List<string>
						{
							"0000", "0001", "0100", "0101"
						}),
						new Group(new List<string>
						{
							"1001", "1011", "1101", "1111"
						}),
						new Group(new List<string>
						{
							"0000", "0010"
						}),
						new Group(new List<string>
						{
							"0010", "1010"
						}),
						new Group(new List<string>
						{
							"1010", "1011"
						})
					}),
					new Coverage(new List<Group>
					{
						new Group(new List<string>
						{
							"0000", "0001", "0100", "0101"
						}),
						new Group(new List<string>
						{
							"1001", "1011", "1101", "1111"
						}),
						new Group(new List<string>
						{
							"0000", "0010"
						}),
						new Group(new List<string>
						{
							"0010", "1010"
						})
					}),
					new Coverage(new List<Group>
					{
						new Group(new List<string>
						{
							"0000", "0001", "0100", "0101"
						}),
						new Group(new List<string>
						{
							"1001", "1011", "1101", "1111"
						}),
						new Group(new List<string>
						{
							"0000", "0010"
						}),
						new Group(new List<string>
						{
							"1010", "1011"
						})
					}),
					new Coverage(new List<Group>
					{
						new Group(new List<string>
						{
							"0000", "0001", "0100", "0101"
						}),
						new Group(new List<string>
						{
							"1001", "1011", "1101", "1111"
						}),
						new Group(new List<string>
						{
							"0010", "1010"
						})
					}),
					new Coverage(new List<Group>
					{
						new Group(new List<string>
						{
							"0000", "0001", "0100", "0101"
						}),
						new Group(new List<string>
						{
							"1001", "1011", "1101", "1111"
						}),
						new Group(new List<string>
						{
							"0010", "1010"
						}),
						new Group(new List<string>
						{
							"1010", "1011"
						})
					})
				}
			};

			yield return new object[]
			{
				new KMap(3, [0, 1, 2], [4, 5]),
				new HashSet<Coverage>
				{
					new Coverage(new List<Group>
					{
						new Group(new List<string>
						{
							"000", "001", "100", "101"
						}),
						new Group(new List<string>
						{
							"000", "010"
						})
					})
				}
			};
		}

		[Theory]
		[MemberData(nameof(Minimize_TestData))]
		public void Given_KMap_When_Minimize_Then_ReturnCorrectValue(KMap map, HashSet<Coverage> expected)
		{
			var actual = map.Minimize();

			actual.Should().BeEquivalentTo(expected);
		}
	}
}