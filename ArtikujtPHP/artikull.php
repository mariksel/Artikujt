
<?php

    $artikull = Service::$artikull;

    $isNew = $artikull->isNew;

    $isNewValue = stringAsValue(boolToString($isNew));
    $idValue = stringAsValue($artikull->id);
    $emriValue = stringAsValue($artikull->emri);
    $njesiaValue = stringAsValue($artikull->njesia);
    $dataSkadencesValue = stringAsValue($artikull->dataSkadences->format('Y-m-d'));
    $cmimiValue = stringAsValue($artikull->cmimi);
    $llojImportuarValue = boolToChecked($artikull->lloj == Lloj::I);
    $llojIVendiValue = boolToChecked($artikull->lloj == Lloj::V);
    $kaTvshValue = boolToChecked($artikull->kaTvsh);
    $barkodValue = stringAsValue($artikull->barkod);

    function boolToString(bool $b): string{
        return $b ? 'true' : 'false';
    }
    function boolToChecked(bool $b): string{
        global $isNew;
        return ($isNew ?  '' : ($b?'checked': ''));
    }
    function boolToSelected(bool $b): string{
        global $isNew;
        return ($isNew ?  '' : 'selected');
    }

    function stringAsValue($value): string{
        global $isNew;
        return ($isNew ?  '' : 'value="'.$value.'"');
    }
?>

<?php  if (Service::$success != null): ?>

    <div class="alert alert-success" role="alert">
        <?=Service::$success?>
    </div>
<?php endif; ?>

<?php  if (Service::$error != null): ?>

<div class="alert alert-danger" role="alert">
    <?=Service::$error?>
</div>
<?php endif; ?>

<form name="artikullform" method="post" onsubmit="ruajButton.disabled = true; return true;">

    <input type="hidden" name="id"  <?=$idValue?>/>
    <input type="hidden" name="isNew" <?=$isNewValue?>/>


    <div class="form-row">
        <div class="form-group col-md-6">
            <label for="inputEmri4">Emri</label>
            <input required type="text" class="form-control" id="inputEmri4" placeholder="Emri" name="emri" <?=$emriValue?> >
        </div>
        <div class="form-group col-md-6">
            <label for="inputNjesi4">Njesia</label>
            <input required type="text" class="form-control" id="inputNjesi4" placeholder="Njesia" name="njesia" <?=$njesiaValue?>>
        </div>
    </div>
    <div class="form-row">
        <div class="form-group col-md-6">
            <label for="inputDataSkadences4">Data Skadences</label>
            <input type="date" class="form-control" id="inputDataSkadences4" required name="dataSkadences" <?=$dataSkadencesValue?>>
        </div>
        <div class="form-group col-md-6">
            <label for="inputCmimi4">Cmimi</label>
            <input required type="number" class="form-control" id="inputCmimi4" placeholder="Cmimi" step='0.01' name="cmimi" <?=$cmimiValue?> 
            min="0" onkeydown="javascript: return event.keyCode !== 69" >
        </div>
    </div>
    <div class="form-row">
        <div class="form-group col-md-6">
            <label for="inputLloj4">Lloj</label>
            <div class="input-group">
                <div class="input-group-prepend">
                    <div class="input-group-text">
                        <input type="radio" required name="lloj" value="<?=Lloj::I?>" <?=$llojImportuarValue?>>
                    </div>
                    
                    <span class="input-group-text">Importuar</span>
                </div>
            </div>
            <div class="input-group">
                <div class="input-group-prepend">
                    <div class="input-group-text">
                        <input type="radio" name="lloj" value="<?=Lloj::V?>" <?=$llojIVendiValue?>>
                    </div>
                    <span class="input-group-text">Vendi</span>
                </div>
            </div>
        </div>
        <div class="custom-control custom-checkbox mb-3">
            <input type="checkbox" class="custom-control-input" id="inputkaTvsh4" name="kaTvsh" <?=$kaTvshValue?> value="true">
            <label class="custom-control-label" for="inputkaTvsh4">Ka TVSH?</label>
        </div>
    </div>
    <div class="form-row">
        <div class="form-group col-md-6">
            <label for="inputTipi4">Tipi</label>
            <select class=" form-control" required name="tipi">
                <option value="<?=Tipi::None?>">Selekto Tipin</option>
                <option <?=boolToSelected($artikull->tipi == Tipi::Ushqimore)?> value="<?=Tipi::Ushqimore?>">Ushqimore</option>
                <option <?=boolToSelected($artikull->tipi == Tipi::Bulmet)?>  value="<?=Tipi::Bulmet?>">Bulmet</option>
                <option <?=boolToSelected($artikull->tipi == Tipi::Pije)?>  value="<?=Tipi::Pije?>">Pije</option>
                <option <?=boolToSelected($artikull->tipi == Tipi::Embelsire)?>  value="<?=Tipi::Embelsire?>">Embelsire</option>
            </select>
        </div>
        <div class="form-group col-md-6">
            <label for="inputBarkod4">Barkod</label>
            <input required type="text" class="form-control" id="inputBarkod4" placeholder="Barkod" name="barkod" <?=$barkodValue?>>
        </div>
    </div>
    <input type="submit" id="ruaj-artukull-button" class="hidden"  name="ruajButton"/>


</form>

<form name="artikullformdelete" method="post" action="/artikull/fshi?id=<?=$artikull->id?>">
    <input type="hidden" name="id" value="@(Model.Id)" />
    <input type="submit" id="fshi-artukull-button" class="hidden" />
</form>


<label for="ruaj-artukull-button" class="btn btn-primary" tabindex="0">Ruaj</label>

<?php  if (!$isNew): ?>
    <label for="fshi-artukull-button" class="btn btn-danger" tabindex="0">Fshi</label>
<?php endif; ?>


