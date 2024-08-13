using System.Net;

namespace ECommerceApp.Business.Base
{
    public class ResponseHandler
    {
        public Response<T> Deleted<T>(string message = null)
        {
            return new Response<T>
            {
                StatusCode = HttpStatusCode.OK,
                Succeeded = true,
                Message = message == null ? "Deleted Succeefully" : message
            };
        }
        public Response<T> Success<T>(T? entity, object meta = null)
        {
            return new Response<T>
            {
                StatusCode = HttpStatusCode.OK,
                Succeeded = true,
                Message = "Succeefully",
                Data = entity,
                Meta = meta
            };
        }
        public Response<T> Unauthorized<T>(string message = null)
        {
            return new Response<T>
            {
                StatusCode = HttpStatusCode.Unauthorized,
                Succeeded = false,
                Message = message,
            };
        }
        public Response<T> BadRequest<T>(string message = null)
        {
            return new Response<T>
            {
                StatusCode = HttpStatusCode.BadRequest,
                Succeeded = false,
                Message = message
            };
        }

        public Response<T> NotFound<T>(string message = null)
        {
            return new Response<T>
            {
                StatusCode = HttpStatusCode.NotFound,
                Succeeded = false,
                Message = message == null ? "Not Found" : message
            };
        }

        public Response<T> Created<T>(T entity, object Meta = null)
        {
            return new Response<T>()
            {
                Data = entity,
                StatusCode = HttpStatusCode.Created,
                Succeeded = true,
                Message = "Created",
                Meta = Meta
            };
        }

        public Response<T> UnProcessableEntity<T>(string message = null)
        {
            return new Response<T>
            {
                StatusCode = HttpStatusCode.UnprocessableEntity,
                Succeeded = false,
                Message = message == null ? "UnProcessable Entity" : message
            };
        }
    }

}
