using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverlappingTimeSlots
{
	class Program
	{
		static void Main(string[] args)
		{

		}
		public class TimeRanges
		{
			private List<TimeRange> _mergedTimeRanges = new List<TimeRange>();
			
			public void Add(TimeRange timeRange)
			{
				if (!_mergedTimeRanges.Any(x => x.IsOverLap(timeRange)))
				{
					_mergedTimeRanges.Add(timeRange);
					return;
				}
				while (_mergedTimeRanges.Any(x => x.IsOverLap(timeRange) && x != timeRange))
				{
					TimeRange toMergeRange = _mergedTimeRanges.First(x => x.IsOverLap(timeRange));
					toMergeRange.Merge(timeRange);
					timeRange = toMergeRange;
				}
			}

			public IEnumerable<TimeRange> GetMergedRanges()
			{
				return _mergedTimeRanges;
			}
		}

		public class TimeRange
		{
			public DateTime Start { get; private set; }
			public DateTime End { get; private set; }
			public TimeRange(DateTime start, DateTime end)
			{
				if (start >= end)
					throw new ArgumentException("Invalid time range, end must be later than start");
				Start = start;
				End = end;
			}

			public void Merge(TimeRange timeRange)
			{
				if (!IsOverLap(timeRange))
					throw new ArgumentException("Cannot merge timeranges that don't overlap", "timeRange");
				if (End < timeRange.End)
					End = timeRange.End;
				if (timeRange.Start < Start)
					Start = timeRange.Start;
			}

			public bool IsOverLap(TimeRange timeRange)
			{
				if (timeRange.End < Start)
					return false;
				if (timeRange.Start > End)
					return false;
				return true;
			}

			public bool Equals(TimeRange other)
			{
				if (ReferenceEquals(null, other)) return false;
				if (ReferenceEquals(this, other)) return true;
				return other.Start.Equals(Start) && other.End.Equals(End);
			}

			public override bool Equals(object obj)
			{
				if (ReferenceEquals(null, obj)) return false;
				if (ReferenceEquals(this, obj)) return true;
				if (obj.GetType() != typeof(TimeRange)) return false;
				return Equals((TimeRange)obj);
			}

			public override int GetHashCode()
			{
				unchecked
				{
					return (Start.GetHashCode() * 397) ^ End.GetHashCode();
				}
			}
		}

	}
}
