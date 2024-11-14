using Pustok.BLL.Helpers.Contracts;
using Pustok.BLL.Services.Abstraction;
using Pustok.BLL.Services.Implementation.Generic;
using Pustok.DAL.Repositories.Abstraction;
using Pustok.DAL.Repositories.Abstraction.Generic;

namespace Pustok.BLL.Services.Implementation;

public class SliderManager : CrudManager<Slider, SliderViewModel, SliderListViewModel, SliderCreateViewModel, SliderUpdateViewModel>, ISliderService
{
    private readonly ISliderRepository _sliderRepository;
    private readonly ICloudinaryService _cloudinaryService;

    public SliderManager(IRepository<Slider> repository, IMapper mapper, ISliderRepository sliderRepository, ICloudinaryService cloudinaryService) : base(repository, mapper)
    {
        _sliderRepository = sliderRepository;
        _cloudinaryService = cloudinaryService;
    }
    public override async Task<SliderViewModel> CreateAsync(SliderCreateViewModel createViewModel)
    {
        var imageUrl = await _cloudinaryService.ImageCreateAsync(createViewModel.ImageFile);

        createViewModel.ImageUrl = imageUrl;

        return await base.CreateAsync(createViewModel);
    }
    public override async Task<SliderViewModel> UpdateAsync(SliderUpdateViewModel updateViewModel)
    {
        var foundSlider = await _sliderRepository.GetAsync(updateViewModel.Id);

        if(updateViewModel.ImageFile != null)
        {
            await _cloudinaryService.FileDeleteAsync(foundSlider.ImageUrl);

            foundSlider.ImageUrl = await _cloudinaryService.ImageCreateAsync(updateViewModel.ImageFile);
        }

        foundSlider = _mapper.Map(updateViewModel, foundSlider);

        await _sliderRepository.UpdateAsync(foundSlider);

        var foundSliderVm = _mapper.Map<SliderViewModel>(foundSlider);

        return foundSliderVm;
    }
    public override async Task<SliderViewModel> RemoveAsync(int id)
    {
        var slider = await _sliderRepository.GetAsync(id);

        await _cloudinaryService.FileDeleteAsync(slider.ImageUrl);

        return await base.RemoveAsync(id);
    }
}

