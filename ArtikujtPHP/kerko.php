
<?php 
    $artikujt = Service::$pagination->models;
    $pages = Service::$pagination->pages;
?>

<?php  if (Service::$success != null): ?>

<div class="alert alert-success" role="alert">
    <?=Service::$success?>
</div>
<?php endif; ?>

<ul class="list-group ">
    <?php foreach($artikujt as $artikull): ?>
        <a href="/?id=<?= $artikull->id?>" class="card">
            <li class="list-group-item list-group-item-action">
                <span class="badge badge-secondary badge-pill"><?= $artikull->id?></span>
                <span class="mx-5 h5"><?= $artikull->emri?></span>
                <span class="badge badge-primary badge-pill float-right"><?= $artikull->cmimi?> LEK</span>
            </li>

        </a>
    <?php endforeach; ?>


</ul>
<br />

<nav aria-label="Page navigation example">
    <ul class="pagination">
        <?php foreach($pages as $page): ?>

            <li class="page-item <?= $page->isActive ? 'active' : ''?>">
                <a class="page-link" href="/kerko?index=<?= $page->index?>">
                    <?= $page->index?>

                    <?php  if ($page->isActive): ?>

                        <span class="sr-only">(current)</span>
                 
                    <?php endif; ?>
                </a>
            </li>

        <?php endforeach; ?>
    </ul>
</nav>
