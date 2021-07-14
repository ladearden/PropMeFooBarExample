using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTemplate.Services
{
    public class FooBarService : IFooBarService
    {
        private readonly ILogger _logger;
        public string Test(int position, string input)
        {
            try
            {
                return foobar(position, input);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return "error";
            }
        }

        private bool divisibleBy3(int position)
        {
            try
            {
                return position % 3 == 0;
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return false;
            }
        }

        private bool divisibleBy5(int position)
        {
            try
            {
                return position % 5 == 0;
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return false;
            }
        }

        private bool inputIsFoo(string input)
        {
            try
            {
                return input.ToLower() == "foo";
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return false;
            }
        }

        private bool inputIsBar(string input)
        {
            try
            {
                return input.ToLower() == "bar";
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return false;
            }
        }

        private bool inputIsFooBar(string input)
        {
            try
            {
                return input.ToLower() == "foobar";
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return false;
            }
        }

        private string foobar(int position, string input)
        {
            try
            {
                if (divisibleBy3(position) && divisibleBy5(position))
                {
                    if (inputIsFooBar(input))
                        return "foobar";
                    return "bad request";
                }
                else if (divisibleBy3(position))
                {
                    if (inputIsFoo(input))
                        return "foo";
                    return "bad request";
                }
                else if (divisibleBy5(position))
                {
                    if (inputIsBar(input))
                        return "bar";
                    return "bad request";
                }
                if (Int32.TryParse(input, out _))
                {
                    if (position == Int32.Parse(input))
                    {
                        return input;
                    }
                }

            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return "error";
            }
            return "bad request";
        }
    }

    public interface IFooBarService
    {

    }
}
