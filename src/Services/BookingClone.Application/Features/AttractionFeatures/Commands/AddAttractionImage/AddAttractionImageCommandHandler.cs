using AutoMapper;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using BookingClone.Application.Features.AttractionFeatures.DTOs;
using BookingClone.Domain.Contracts;
using MediatR;

namespace BookingClone.Application.Features.AttractionFeatures.Commands.AddAttractionImage;

internal sealed class AddAttractionImageCommandHandler : IRequestHandler<AddAttractionImageCommand, List<AttractionImageDto>?>
{
    private readonly IAttractionRepository _attractionRepository;
    private readonly IMapper _mapper;

    public AddAttractionImageCommandHandler(IAttractionRepository repository, IMapper mapper)
    {
        _attractionRepository = repository;
        _mapper = mapper;
    }

    public async Task<List<AttractionImageDto>?> Handle(AddAttractionImageCommand request, CancellationToken cancellationToken)
    {
        var attraction = await _attractionRepository.GetAttractionDetails(request.ID, cancellationToken);

        if (attraction is null)
        {
            return null;
        }

        var blobServiceClient = new BlobServiceClient("AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;DefaultEndpointsProtocol=http;BlobEndpoint=http://127.0.0.1:10000/devstoreaccount1;QueueEndpoint=http://127.0.0.1:10001/devstoreaccount1;TableEndpoint=http://127.0.0.1:10002/devstoreaccount1;");
        BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient("images-blob");
        await containerClient.CreateIfNotExistsAsync(PublicAccessType.BlobContainer, cancellationToken: cancellationToken);

        foreach (var item in request.Images)
        {
            //var fileName = ContentDispositionHeaderValue.Parse(item.ContentDisposition).FileName.ToString();
            //var x = Uri.EscapeDataString(fileName);
            var fileName = Guid.NewGuid().ToString("N");
            await containerClient.UploadBlobAsync(fileName, item.OpenReadStream(), cancellationToken);
            attraction.Images.Add(new() { ID = attraction.ID, ImageUrlPath = $"{containerClient.Uri}/{fileName}" });
        }

        await _attractionRepository.SaveAsync(cancellationToken);
        return _mapper.Map<List<AttractionImageDto>>(attraction.Images);
    }
}
