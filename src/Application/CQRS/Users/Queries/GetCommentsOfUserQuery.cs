using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.CQRS.Comments.Models;
using Application.Pagination.Common.Models;
using Application.Pagination.Common.Models.PagedList;
using Application.Pagination.Extensions;
using Application.Persistence.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;

namespace Application.CQRS.Users.Queries
{
    public class GetCommentsOfUserQuery : IRequest<IPagedList<CommentDto>>, IPaginationRequest
    {
        #region Properties

        public string UserId { get; set; }

        #endregion

        #region IPaginationInfo

        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        #endregion

        #region Classes

        public class Handler : IRequestHandler<GetCommentsOfUserQuery, IPagedList<CommentDto>>
        {
            #region Fields

            private readonly IMapper _mapper;
            private readonly IXNewsDbContext _context;

            #endregion

            #region Constructors

            public Handler(IXNewsDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            #endregion

            #region IRequestHandler<GetCommentsOfUserQuery, IPagedList<CommentDto>>

            public async Task<IPagedList<CommentDto>> Handle(GetCommentsOfUserQuery request,
                CancellationToken cancellationToken)
            {
                return await _context.Comment
                    .Where(c => c.UserId == request.UserId)
                    .OrderBy(c => c.CommentId)
                    .ProjectTo<CommentDto>(_mapper.ConfigurationProvider)
                    .ProjectToPagedListAsync(request, cancellationToken)
                    .ConfigureAwait(false);
            }

            #endregion
        }

        #endregion
    }
}