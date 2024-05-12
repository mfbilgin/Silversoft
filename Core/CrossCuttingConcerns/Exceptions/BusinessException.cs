namespace Core.CrossCuttingConcerns.Exceptions.Business;


public class BusinessException(string message) : Exception(message);