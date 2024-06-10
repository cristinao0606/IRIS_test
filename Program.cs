// See https://aka.ms/new-console-template for more information

//problem 1
string input = "[()]{}{[()()]()}";
var isBalanced = CheckBrackets(input);
Console.WriteLine($"Balanced? {isBalanced}");

//problem 2
int[] nums1 = { 2, 2, 1 };

int single = SingleNumber(nums1);
Console.WriteLine($"Single number {single}");



bool CheckBrackets(string input)
{
    Stack<char> stack = new Stack<char>();
    foreach (char c in input)
    {
        if (c == '{' || c == '[' || c == '(')
        {
            stack.Push(c);
        }
        else
             if (c == ')' || c == '}' || c == ']')
        {
            if (stack.Count == 0) { return false; }

            char c1 = stack.Pop();
            if (!isPair(c1, c))
            {
                return false;
            }

        }

    }
    if(stack.Count == 0) { return true; }
    return false;
}

bool isPair(char c1, char c2)
{
    if(( c1 =='(' && c2 == ')') || (c1 == '{' && c2 == '}' || c1=='[' && c2 == ']')){  return true; }
         
    return false;
}

int SingleNumber(int[] listNumbers)
{
    HashSet<int> set = new HashSet<int>();
    foreach (int num in listNumbers)
    {
        if (set.Contains(num))
        {
            set.Remove(num);
        }
        else
        {
            set.Add(num);
        }
    }
    foreach (int num in set)
    {
        return num;
    }
    throw new InvalidOperationException("Exception : no single number exists!");
}

int SingleNumberTest(int[] listNumbers)
{
    Dictionary<int, int> countMap = new Dictionary<int, int>();
    foreach (int num in listNumbers)
    {
        if (countMap.ContainsKey(num))
        {
            countMap[num]++;
        }
        else
        {
            countMap[num] = 1;
        }
    }
    foreach (KeyValuePair<int, int> kvp in countMap)
    {
        if (kvp.Value == 1)
        {
            return kvp.Key;
        }
    }
    throw new InvalidOperationException("Exception : no single number exists!");
}