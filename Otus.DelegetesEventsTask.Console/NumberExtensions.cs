namespace Otus.DelegetesEventsTask
{
    public static class NumberExtensions
    {
        public static T GetMax<T>(this IEnumerable<T> collection, Func<T, float> convertToNumber) where T : class
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            if (convertToNumber == null) throw new ArgumentNullException(nameof(convertToNumber));

            var list = collection.ToList();
            if (list.Count == 0) throw new InvalidOperationException("Коллекция пустая.");

            T maxElement = list[0];
            float maxValue = convertToNumber(maxElement);

            for (int i = 1; i < list.Count; i++)
            {
                float currentValue = convertToNumber(list[i]);
                if (currentValue > maxValue)
                {
                    maxValue = currentValue;
                    maxElement = list[i];
                }
            }

            return maxElement;
        }
    }
}
