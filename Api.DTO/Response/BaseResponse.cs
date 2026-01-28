namespace Api.Common.Response
{
    /// <summary>
    /// Representa una respuesta base genérica para todas las respuestas de la API.
    /// Contiene información sobre el éxito de la operación, un mensaje y los datos resultantes.
    /// </summary>
    /// <typeparam name="T">El tipo de los datos que se devolverán en la respuesta.</typeparam>
    public class BaseResponse<T>
    {
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public BaseResponse() { }

        /// <summary>
        /// Constructor para inicializar una respuesta con éxito y mensaje.
        /// </summary>
        /// <param name="isSuccess">Indica si la operación fue exitosa.</param>
        /// <param name="message">Un mensaje descriptivo sobre el resultado de la operación.</param>
        public BaseResponse(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }

        /// <summary>
        /// Constructor para inicializar una respuesta exitosa con datos.
        /// </summary>
        /// <param name="data">Los datos resultantes de la operación.</param>
        public BaseResponse(T data)
        {
            IsSuccess = true;
            Data = data;
        }

        /// <summary>
        /// Obtiene o establece un valor que indica si la operación fue exitosa.
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Obtiene o establece un mensaje descriptivo sobre el resultado.
        /// </summary>
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// Obtiene o establece los datos resultantes de la operación.
        /// </summary>
        public T? Data { get; set; }
    }

    /// <summary>
    /// Representa una respuesta base no genérica para operaciones que no devuelven datos.
    /// </summary>
    public class BaseResponse : BaseResponse<object>
    {
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public BaseResponse() : base() { }

        /// <summary>
        /// Constructor para inicializar una respuesta con éxito y mensaje.
        /// </summary>
        /// <param name="isSuccess">Indica si la operación fue exitosa.</param>
        /// <param name="message">Un mensaje descriptivo sobre el resultado de la operación.</param>
        public BaseResponse(bool isSuccess, string message) : base(isSuccess, message) { }
    }
}
